variable "acr_resource_group_name" {
  description = "The name of the resource group for ACR"
  type        = string
}

variable "location" {
  description = "The location of the resource group"
  type        = string
}

variable "acr_name" {
  description = "The name of the Azure Container Registry"
  type        = string
}

variable "acr_sku" {
  description = "The SKU of the Azure Container Registry"
  type        = string
}

variable "subscription_id" {
  description = "The subscription ID for Azure"
  type        = string
}
