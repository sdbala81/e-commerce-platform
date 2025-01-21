package database

import (
	"fmt"
	"github.com/rs/zerolog/log"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
	"order/config"
	"order/models"
)

// Database connection function
func Connect() (*gorm.DB, error) {
	cfg := config.LoadConfig()

	dbConnectionString := fmt.Sprintf("host=%s user=%s password=%s dbname=%s port=%d",
		cfg.Database.Host, cfg.Database.User, cfg.Database.Password, cfg.Database.Name, cfg.Database.Port)

	log.Info().
		Str("module", "database").
		Str("connection_string", dbConnectionString).
		Msg("Connecting to the database")

	db, err := gorm.Open(postgres.Open(dbConnectionString), &gorm.Config{})
	if err != nil {
		log.Error().Err(err).Str("module", "database").Msg("Failed to connect to the database")
		return nil, fmt.Errorf("failed to connect to the database: %w", err)
	}

	log.Info().Str("module", "database").Msg("Connected to the database successfully")

	// Auto-migrate the schema
	err = db.AutoMigrate(&models.Order{}, &models.OrderItem{})
	if err != nil {
		log.Error().Err(err).Str("module", "database").Msg("Failed to migrate database schema")
		return nil, fmt.Errorf("failed to migrate database schema: %w", err)
	}

	log.Info().Str("module", "database").Msg("Database schema migrated successfully")

	return db, nil
}
