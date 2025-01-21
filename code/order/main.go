package main

import (
	"os"
	"strconv"
	"time"

	"github.com/gin-gonic/gin"
	"github.com/rs/zerolog"
	"github.com/rs/zerolog/log"
	"order/config"
	"order/middlewares"
	"order/routes"
)

func main() {
	// Configure Zerolog
	zerolog.TimeFieldFormat = time.RFC3339
	zerolog.SetGlobalLevel(zerolog.InfoLevel)
	log.Logger = log.Output(zerolog.ConsoleWriter{Out: os.Stdout, TimeFormat: time.RFC3339})

	// Load configuration
	config := config.LoadConfig()
	log.Info().
		Str("host", config.Server.Host).
		Int("port", config.Server.Port).
		Str("database", config.Database.Name).
		Str("db_user", config.Database.User).
		Msg("Configuration loaded")

	port := os.Getenv("PORT")
	if port == "" {
		port = strconv.Itoa(config.Server.Port)
	}

	// Initialize Gin router
	router := gin.New()
	router.Use(gin.Logger())
	router.Use(gin.Recovery())
	router.Use(middlewares.RecoveryMiddleware)

	// Register routes
	routes.OrderRoutes(router)

	// Start server
	log.Info().Str("port", port).Msg("Starting server")
	if err := router.Run(":" + port); err != nil {
		log.Fatal().Err(err).Msg("Failed to start server")
	}
}
