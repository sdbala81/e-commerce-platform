package orderController

import (
	"github.com/gin-gonic/gin"
	"github.com/google/uuid"
	"order/models"
)

func GetOrderById() gin.HandlerFunc {
	return func(context *gin.Context) {
		id := context.Param("order_id")
		orderID, err := uuid.Parse(id)
		if err != nil {
			context.JSON(400, gin.H{"error": "Invalid order ID"})
			return
		}

		var order models.Order
		if err := ordersDb.Preload("Items").First(&order, "id = ?", orderID).Error; err != nil {
			context.JSON(404, gin.H{"error": "Order not found"})
			return
		}

		context.JSON(200, order)
	}
}
