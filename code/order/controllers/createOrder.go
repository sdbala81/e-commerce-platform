package orderController

import (
	"github.com/gin-gonic/gin"
	"github.com/rs/zerolog/log"
	"order/database"
	"order/models"
)

var ordersDb, _ = database.Connect()

func CreateOrder() gin.HandlerFunc {
	return func(context *gin.Context) {
		var order models.Order

		// Bind JSON to order
		if err := context.ShouldBindJSON(&order); err != nil {
			log.Error().Err(err).Str("module", "order").Msg("Failed to bind JSON")
			context.JSON(400, gin.H{"error": err.Error()})
			return
		}

		// Begin transaction
		tx := ordersDb.Begin()
		if err := tx.Error; err != nil {
			log.Error().Err(err).Str("module", "order").Msg("Failed to begin transaction")
			context.JSON(500, gin.H{"error": err.Error()})
			return
		}

		// Create order
		if err := tx.Create(&order).Error; err != nil {
			tx.Rollback()
			log.Error().Err(err).Str("module", "order").Msg("Failed to create order")
			context.JSON(500, gin.H{"error": err.Error()})
			return
		}

		// Commit transaction
		if err := tx.Commit().Error; err != nil {
			log.Error().Err(err).Str("module", "order").Msg("Failed to commit transaction")
			context.JSON(500, gin.H{"error": err.Error()})
			return
		}

		// Success log
		log.Info().
			Str("module", "order").
			Str("order_id", order.ID.String()).
			Msg("Order created successfully")

		context.JSON(200, gin.H{
			"message": "Order created successfully",
			"order":   order,
		})
	}
}
