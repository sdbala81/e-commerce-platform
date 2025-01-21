package models

import "github.com/google/uuid"

type OrderItem struct {
	ID        uuid.UUID `json:"id" gorm:"type:uuid;primary_key;"`
	ProductID uuid.UUID `json:"product_id" gorm:"type:uuid;"`
	Quantity  int       `json:"quantity"`
	OrderID   uuid.UUID `json:"order_id" gorm:"type:uuid;"`
	Order     Order     `json:"-" gorm:"constraint:OnUpdate:CASCADE,OnDelete:CASCADE;"`
}
