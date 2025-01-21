output "aks_cluster_name" {
  value = azurerm_kubernetes_cluster.aks.name
}

output "kube_config" {
  value     = azurerm_kubernetes_cluster.aks.kube_admin_config_raw
  sensitive = true
}

output "managed_identity_client_id" {
  value       = azurerm_user_assigned_identity.managed_identity.client_id
  description = "Client ID of the User-Managed Identity"
}

output "managed_identity_principal_id" {
  value       = azurerm_user_assigned_identity.managed_identity.principal_id
  description = "Principal ID of the User-Managed Identity"
}

output "managed_identity_resource_id" {
  value       = azurerm_user_assigned_identity.managed_identity.id
  description = "Resource ID of the User-Managed Identity"
}
