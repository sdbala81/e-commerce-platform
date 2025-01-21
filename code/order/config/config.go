package config

// Configuration struct for the entire application
type Configuration struct {
	Server struct {
		Port int    `mapstructure:"port"`
		Host string `mapstructure:"host"`
	} `mapstructure:"server"`

	Database struct {
		User     string `mapstructure:"user"`
		Password string `mapstructure:"password"`
		Name     string `mapstructure:"name"`
		Port     int    `mapstructure:"port"`
		Host     string `mapstructure:"host"`
	} `mapstructure:"database"`
}
