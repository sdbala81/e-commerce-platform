variable "resource_group_name" {
  description = "The name of the resource group"
  default     = "global-tickets-rg"
}

variable "location" {
  description = "The location of the resource group"
  default     = "westeurope"
}

variable "aks_cluster_name" {
  description = "The name of the AKS cluster"
  default     = "global-tickets-aks"
}

variable "node_os_disk_type" {
  description = "The OS disk type for the AKS nodes"
  default     = "Ephemeral"
}

variable "node_os_disk_size" {
  description = "The OS disk size for the AKS nodes"
  default     = 30
}

variable "network_plugin" {
  description = "The network plugin for the AKS cluster"
  default     = "kubenet"
}

variable "acr_name" {
  description = "The name of the Azure Container Registry"
  default     = "globalticketsacr"
}

variable "acr_sku" {
  description = "The SKU of the Azure Container Registry"
  default     = "Standard"
}

variable "subscription_id" {
  description = "The Azure subscription ID"
  default     = "your-subscription-id"
}

variable "node_resource_group" {
  description = "The name of the node resource group"
  default     = "global-tickets-node-rg"
}
