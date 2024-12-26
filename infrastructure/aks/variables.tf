variable "aks_resource_group_name" {
  description = "The name of the resource group for AKS"
  type        = string
}

variable "location" {
  description = "The location of the resource group"
  type        = string
}

variable "aks_cluster_name" {
  description = "The name of the Azure Kubernetes Service cluster"
  type        = string
}

variable "node_resource_group" {
  description = "The resource group for the AKS nodes"
  type        = string
}

variable "node_os_disk_type" {
  description = "The OS disk type for the AKS nodes"
  type        = string
}

variable "node_os_disk_size" {
  description = "The OS disk size for the AKS nodes"
  type        = number
}

variable "network_plugin" {
  description = "The network plugin for the AKS cluster"
  type        = string
}

variable "subscription_id" {
  description = "The subscription ID for the Azure account"
  type        = string
}

