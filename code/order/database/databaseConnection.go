package database

import (
	"fmt"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
	"order/models"
)

// Database connection function
func Connect() (*gorm.DB, error) {
	//dsn := "host=localhost user=globaltickets password=global#tickets@pw dbname=GlobalTickets.Order port=5432"
	dsn := "host=localhost user=postgres password=postgres dbname=GlobalTickets.Order port=5432"
	db, err := gorm.Open(postgres.Open(dsn), &gorm.Config{})
	if err != nil {
		return nil, fmt.Errorf("failed to connect to the database: %w", err)
	}

	// Auto-migrate the schema
	err = db.AutoMigrate(&models.Order{}, &models.OrderItem{})
	if err != nil {
		return nil, fmt.Errorf("failed to migrate database schema: %w", err)
	}

	return db, nil
}
