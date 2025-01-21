package routes

import (
	orderController "order/controllers"

	"github.com/gin-gonic/gin"
)

func OrderRoutes(orderRoutes *gin.Engine) {
	orderRoutes.GET("/orders", orderController.GetAllOrders())
	orderRoutes.GET("/orders/:order_id", orderController.GetOrderById())
	orderRoutes.POST("/orders", orderController.CreateOrder())
	orderRoutes.DELETE("/orders/:order_id", orderController.DeleteOrder())
}
