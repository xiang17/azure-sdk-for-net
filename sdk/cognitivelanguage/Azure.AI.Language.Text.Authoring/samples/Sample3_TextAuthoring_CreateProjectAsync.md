# Creating a Project Asynchronously in Azure AI Language

This sample demonstrates how to create a new project asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Create a Project Asynchronously

To create a new project, call CreateProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample3_TextAuthoring_CreateProjectAsync
string projectName = "MyNewProjectAsync";
var projectData = new
{
    projectName = projectName,
    language = "en",
    projectKind = "CustomEntityRecognition",
    description = "Project description for a Custom Entity Recognition project",
    multilingual = true
};

using RequestContent content = RequestContent.Create(projectData);
Response response = await authoringClient.CreateProjectAsync(projectName, content);

Console.WriteLine($"Project created with status: {response.Status}");
```

To create a project, the CreateProject method sends a request with the necessary project data (such as name, language, and project type). The method returns a Response object indicating the creation status.
