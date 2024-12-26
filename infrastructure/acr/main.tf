resource "azurerm_resource_group" "acr_rg" {
  name     = var.acr_resource_group_name
  location = var.location
}

resource "azurerm_container_registry" "acr" {
  name                = var.acr_name
  resource_group_name = azurerm_resource_group.acr_rg.name
  location            = var.location
  sku                 = "Standard"

  admin_enabled          = false
  anonymous_pull_enabled = true
}
