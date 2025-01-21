package models

import (
	"github.com/google/uuid"
	"time"
)

type Order struct {
	ID         uuid.UUID   `json:"id" gorm:"type:uuid;primary_key;"`
	Amount     float64     `json:"amount"`
	CustomerID uuid.UUID   `json:"customer_id" gorm:"type:uuid;"`
	Status     string      `json:"status"`
	Items      []OrderItem `json:"items" gorm:"foreignKey:OrderID;constraint:OnUpdate:CASCADE,OnDelete:CASCADE;"`
	CreatedAt  time.Time   `json:"created_at"`
	UpdatedAt  time.Time   `json:"updated_at"`
}
