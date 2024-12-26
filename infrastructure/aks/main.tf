resource "azurerm_resource_group" "aks_rg" {
  name     = var.aks_resource_group_name
  location = var.location
}

resource "azurerm_kubernetes_cluster" "aks" {
  name                = var.aks_cluster_name
  location            = var.location
  resource_group_name = azurerm_resource_group.aks_rg.name
  dns_prefix          = "${var.aks_cluster_name}-dns"
  node_resource_group = var.node_resource_group

  default_node_pool {
    name                        = "default"
    node_count                  = 3
    vm_size                     = "Standard_DS3_v2"
    os_disk_type                = var.node_os_disk_type
    os_disk_size_gb             = var.node_os_disk_size
    temporary_name_for_rotation = "defaulttmp"
  }

  network_profile {
    network_plugin = var.network_plugin
  }

  identity {
    type = "SystemAssigned"
  }
}
