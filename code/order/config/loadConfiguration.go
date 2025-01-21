package config

import (
	"github.com/spf13/viper"
	"log"
	"sync"
)

var (
	config     *Configuration
	once       sync.Once // Ensure the config is loaded only once
	configLock sync.RWMutex
)

// LoadConfig initializes and loads the configuration file
func LoadConfig() *Configuration {
	once.Do(func() {
		viper.SetConfigName("config") // Name of the file (without extension)
		viper.SetConfigType("yaml")   // File type
		viper.AddConfigPath(".")      // Path to look for the file

		if err := viper.ReadInConfig(); err != nil {
			log.Fatalf("Error reading config file: %v", err)
		}

		cfg := &Configuration{}
		if err := viper.Unmarshal(cfg); err != nil {
			log.Fatalf("Unable to decode config into struct: %v", err)
		}
		configLock.Lock()
		defer configLock.Unlock()
		config = cfg
	})
	return config
}

// GetConfig provides a thread-safe way to access the configuration
func GetConfig() *Configuration {
	configLock.RLock()
	defer configLock.RUnlock()
	return config
}
