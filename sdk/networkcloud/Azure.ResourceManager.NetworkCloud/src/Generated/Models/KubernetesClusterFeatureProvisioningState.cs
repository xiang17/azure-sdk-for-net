// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> The provisioning state of the Kubernetes cluster feature. </summary>
    public readonly partial struct KubernetesClusterFeatureProvisioningState : IEquatable<KubernetesClusterFeatureProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesClusterFeatureProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KubernetesClusterFeatureProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AcceptedValue = "Accepted";
        private const string CanceledValue = "Canceled";
        private const string DeletingValue = "Deleting";
        private const string FailedValue = "Failed";
        private const string SucceededValue = "Succeeded";
        private const string UpdatingValue = "Updating";

        /// <summary> Accepted. </summary>
        public static KubernetesClusterFeatureProvisioningState Accepted { get; } = new KubernetesClusterFeatureProvisioningState(AcceptedValue);
        /// <summary> Canceled. </summary>
        public static KubernetesClusterFeatureProvisioningState Canceled { get; } = new KubernetesClusterFeatureProvisioningState(CanceledValue);
        /// <summary> Deleting. </summary>
        public static KubernetesClusterFeatureProvisioningState Deleting { get; } = new KubernetesClusterFeatureProvisioningState(DeletingValue);
        /// <summary> Failed. </summary>
        public static KubernetesClusterFeatureProvisioningState Failed { get; } = new KubernetesClusterFeatureProvisioningState(FailedValue);
        /// <summary> Succeeded. </summary>
        public static KubernetesClusterFeatureProvisioningState Succeeded { get; } = new KubernetesClusterFeatureProvisioningState(SucceededValue);
        /// <summary> Updating. </summary>
        public static KubernetesClusterFeatureProvisioningState Updating { get; } = new KubernetesClusterFeatureProvisioningState(UpdatingValue);
        /// <summary> Determines if two <see cref="KubernetesClusterFeatureProvisioningState"/> values are the same. </summary>
        public static bool operator ==(KubernetesClusterFeatureProvisioningState left, KubernetesClusterFeatureProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KubernetesClusterFeatureProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(KubernetesClusterFeatureProvisioningState left, KubernetesClusterFeatureProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KubernetesClusterFeatureProvisioningState"/>. </summary>
        public static implicit operator KubernetesClusterFeatureProvisioningState(string value) => new KubernetesClusterFeatureProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KubernetesClusterFeatureProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KubernetesClusterFeatureProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
