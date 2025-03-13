// This file contains the BeachCard component which displays information about a single beach

// Import necessary Material UI components for the card layout and styling
import { Card, CardContent, CardMedia, Typography, Box } from "@mui/material";
// Card: Container component that provides a styled card
// CardContent: Container for content within Card
// CardMedia: For displaying media (images) in a card
// Typography: Text component with standardized styling
// Box: Wrapper component for layout and styling needs

// Import navigation functionality from React Router
import { useNavigate } from "react-router-dom";
// useNavigate: Hook that returns a function to navigate between pages

// Define and export the BeachCard component
// It receives beach data as a prop using object destructuring
export function BeachCard({ beach }) {
  // Initialize the navigate function from React Router
  // This function will be used to navigate to the beach details page
  const navigate = useNavigate();

  return (
    // Card component to contain all beach information
    <Card
      sx={{
        // Custom styles for the card
        cursor: "pointer", // Changes cursor to hand when hovering to indicate clickable
        border: "none", // Removes default border
        borderRadius: 3, // Rounded corners (3 * 8px = 24px)
        boxShadow: "0 6px 16px rgba(0,0,0,0.12)", // Adds shadow for depth
        "&:hover": {
          // Styles applied when user hovers over the card
          transform: "scale(1.02)", // Makes card slightly larger on hover
          transition: "transform 0.2s ease-in-out", // Smooth animation for the scaling
        },
      }}
      // When the card is clicked, navigate to the beach details page
      // using the beach's id in the URL
      onClick={() => navigate(`/beaches/${beach.id}`)}
    >
      {/* CardMedia displays the beach image */}
      <CardMedia
        component="img" // Renders as an <img> element
        height="260" // Fixed height in pixels
        image={beach.imageUrl} // URL of the beach image
        alt={beach.name} // Accessibility text
        sx={{
          // Custom styles
          objectFit: "cover", // Makes image cover the entire container
        }}
      />
      {/* CardContent contains the text information about the beach */}
      <CardContent sx={{ p: 2 }}>
        {" "}
        {/* p: 2 adds padding (2 * 8px = 16px) */}
        {/* Beach name */}
        <Typography
          variant="h6" // Heading size
          component="div" // HTML element to render
          sx={{
            // Custom styles
            fontWeight: 600, // Semi-bold text
            fontSize: "1.1rem", // Font size
            color: "#222222", // Dark gray color
          }}
        >
          {beach.name}
        </Typography>
        {/* Beach location/area */}
        <Typography
          variant="body2" // Body text size
          sx={{
            // Custom styles
            color: "#717171", // Gray color
            fontSize: "0.95rem", // Font size
            mb: 1, // Margin bottom (1 * 8px = 8px)
          }}
        >
          {beach.area}
        </Typography>
        {/* Box to contain wave height and date information in a row */}
        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
          {/* Wave height information */}
          <Typography
            variant="body2" // Body text size
            sx={{
              // Custom styles
              color: "#222222", // Dark gray color
              fontWeight: 500, // Medium font weight
            }}
          >
            Wave Height: {beach.forecastData[0].height}m
          </Typography>

          {/* Date information with a dot separator */}
          <Typography
            variant="body2" // Body text size
            sx={{
              // Custom styles
              color: "#717171", // Gray color
            }}
          >
            · {beach.forecastData[0].date}
          </Typography>
        </Box>
      </CardContent>
    </Card>
  );
}
