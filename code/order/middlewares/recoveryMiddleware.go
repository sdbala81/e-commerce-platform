package middlewares

import (
	"github.com/gin-gonic/gin"
	"log"
	"net/http"
)

type ErrorResponse struct {
	Error   string
	Message string
}

// RecoveryMiddleware Global error recovery middleware
func RecoveryMiddleware(context *gin.Context) {
	defer func() {
		if err := recover(); err != nil {
			log.Printf("Recovered from panic: %v", err)
			context.JSON(http.StatusInternalServerError, ErrorResponse{
				Error:   "Internal Server Error",
				Message: "An unexpected error occurred",
			})
			context.Abort()
		}
	}()
	context.Next()
}
