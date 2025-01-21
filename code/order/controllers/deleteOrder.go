package orderController

import (
	"net/http"
	"order/models"

	"github.com/gin-gonic/gin"
	"github.com/google/uuid"
)

func DeleteOrder() gin.HandlerFunc {
	return func(context *gin.Context) {
		id := context.Param("order_id")
		orderID, err := uuid.Parse(id)
		if err != nil {
			context.JSON(400, gin.H{"error": "Invalid order ID"})
			return
		}

		// Assuming ordersDb is your database instance and Order is your order model
		if err := ordersDb.Delete(&models.Order{}, orderID).Error; err != nil {
			context.JSON(http.StatusInternalServerError, gin.H{
				"error": "Failed to delete order",
			})
			return
		}

		context.JSON(http.StatusOK, gin.H{
			"message": "Order deleted successfully",
		})
	}
}
