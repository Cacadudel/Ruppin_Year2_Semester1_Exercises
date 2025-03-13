// This file contains mock (fake) data for beach information
// In a real application, this data would come from a database or API
// For learning purposes, we're using static data

// Export a constant array named mockBeaches that contains beach objects
export const mockBeaches = [
  // Each beach object has properties with information about the beach
  {
    id: "1", // Unique identifier for the beach
    name: "Bondi Beach", // Name of the beach
    area: "Sydney", // Location/region of the beach
    description:
      "Iconic Australian beach known for its golden sand and perfect waves", // Brief description
    imageUrl:
      "https://images.unsplash.com/photo-1578922746465-3a80a228f223?auto=format&fit=crop&q=80&w=1000", // URL to the beach image
    forecastData: [
      // Array containing wave forecast information
      {
        date: "2025-03-08", // Date of the forecast
        height: 1.5, // Wave height in meters
        swell: 8, // Swell strength (scale probably 1-15)
        kph: 15, // Wind speed in kilometers per hour
      },
    ],
  },
  // Second beach entry
  {
    id: "2", // Unique identifier
    name: "Pipeline", // Beach name
    area: "Hawaii", // Location
    description: "World-famous surf spot known for its powerful waves", // Description
    imageUrl:
      "https://images.unsplash.com/photo-1506797220058-533e019ac7fa?auto=format&fit=crop&q=80&w=1000", // Image URL
    forecastData: [
      // Forecast data
      {
        date: "2025-03-08",
        height: 3.0, // Higher waves than Bondi Beach
        swell: 12, // Stronger swell
        kph: 20, // Faster wind speed
      },
    ],
  },
  // Third beach entry
  {
    id: "3", // Unique identifier
    name: "Nazaré", // Beach name
    area: "Portugal", // Location
    description: "Home to some of the biggest waves in the world", // Description
    imageUrl:
      "https://images.unsplash.com/photo-1502680390469-be75c86b636f?auto=format&fit=crop&q=80&w=1000", // Image URL
    forecastData: [
      // Forecast data
      {
        date: "2025-03-08",
        height: 5.0, // Very high waves (Nazaré is famous for massive waves)
        swell: 15, // Very strong swell
        kph: 25, // High wind speed
      },
    ],
  },
  // The pattern continues with more beach entries...
  // Each beach follows the same data structure
  // In a real application, this could be hundreds of beaches
  // Each with their own unique properties and forecast data

  // ... other beach entries would follow the same format ...
  {
    id: "4",
    name: "Uluwatu",
    area: "Bali",
    description: "Legendary surf spot with perfect barrels",
    imageUrl:
      "https://images.unsplash.com/photo-1537519646099-335112f03225?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 2.0, swell: 10, kph: 12 }],
  },
  {
    id: "5",
    name: "Jeffreys Bay",
    area: "South Africa",
    description: "One of the best right-hand point breaks in the world",
    imageUrl:
      "https://images.unsplash.com/photo-1455729552865-3658a5d39692?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 2.5, swell: 9, kph: 18 }],
  },
  {
    id: "6",
    name: "Trestles",
    area: "California",
    description: "Premium California surf spot with consistent waves",
    imageUrl:
      "https://images.unsplash.com/photo-1514389225423-e7515e17c3b1?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 1.8, swell: 7, kph: 14 }],
  },
  {
    id: "7",
    name: "Bells Beach",
    area: "Victoria",
    description: "Historic Australian surf location",
    imageUrl:
      "https://images.unsplash.com/photo-1520116468816-95b69f847357?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 2.2, swell: 11, kph: 16 }],
  },
  {
    id: "8",
    name: "Mundaka",
    area: "Spain",
    description: "Europe's finest left-hand barrel",
    imageUrl:
      "https://images.unsplash.com/photo-1516091877740-fde016699f2c?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 2.8, swell: 13, kph: 22 }],
  },
  {
    id: "9",
    name: "Teahupo'o",
    area: "Tahiti",
    description: "Most challenging wave in the world",
    imageUrl:
      "https://images.unsplash.com/photo-1500520198921-6d4704f98092?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 4.0, swell: 14, kph: 19 }],
  },
  {
    id: "10",
    name: "Raglan",
    area: "New Zealand",
    description: "New Zealand's longest left-hand break",
    imageUrl:
      "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?auto=format&fit=crop&q=80&w=1000",
    forecastData: [{ date: "2025-03-08", height: 1.9, swell: 8, kph: 17 }],
  },
];
