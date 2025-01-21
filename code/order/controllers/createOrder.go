package orderController

import (
	"order/database"
	"order/models"

	"github.com/gin-gonic/gin"
)

var ordersDb, _ = database.Connect()

func CreateOrder() gin.HandlerFunc {
	return func(context *gin.Context) {
		var order models.Order
		//var orderItems []models.OrderItem

		if err := context.ShouldBindJSON(&order); err != nil {
			context.JSON(400, gin.H{"error": err.Error()})
			return
		}

		// if err := context.ShouldBindJSON(&orderItems); err != nil {
		// 	context.JSON(400, gin.H{"error": err.Error()})
		// 	return
		// }

		tx := ordersDb.Begin()
		if err := tx.Error; err != nil {
			context.JSON(500, gin.H{"error": err.Error()})
			return
		}

		if err := tx.Create(&order).Error; err != nil {
			tx.Rollback()
			context.JSON(500, gin.H{"error": err.Error()})
			return
		}

		// for _, item := range orderItems {
		// 	item.OrderID = order.ID
		// 	if err := tx.Create(&item).Error; err != nil {
		// 		tx.Rollback()
		// 		context.JSON(500, gin.H{"error": err.Error()})
		// 		return
		// 	}
		// }

		if err := tx.Commit().Error; err != nil {
			context.JSON(500, gin.H{"error": err.Error()})
			return
		}

		context.JSON(200, gin.H{
			"message": "Order created successfully",
			"order":   order,
			// "items":   orderItems,
		})
	}
}
