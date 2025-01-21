package orderController

import (
	"github.com/gin-gonic/gin"
	"order/models"
)

func GetAllOrders() gin.HandlerFunc {
	return func(c *gin.Context) {
		var orders []models.Order
		if err := ordersDb.Preload("Items").Find(&orders).Error; err != nil {
			c.JSON(500, gin.H{"error": err.Error()})
			return
		}
		c.JSON(200, gin.H{
			"orders": orders,
		})
	}
}
