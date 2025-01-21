package main

import (
	"github.com/gin-gonic/gin"
	"order/routes"
	"os"
)

func main() {
	port := os.Getenv("PORT")
	if port == "" {
		port = "8000"
	}

	router := gin.New()
	router.Use(gin.Logger())
	router.Use(gin.Recovery())

	routes.OrderRoutes(router)

	router.Run(":" + port)

}
