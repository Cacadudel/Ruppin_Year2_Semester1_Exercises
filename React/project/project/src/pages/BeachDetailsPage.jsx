// This file contains the BeachDetailsPage component which shows detailed information about a specific beach

// Import necessary dependencies and components
// useParams is a hook from React Router that allows us to access URL parameters
import { useParams } from "react-router-dom";

// Import Material UI components for layout and styling
import { Container, Typography, Box, Paper, Grid } from "@mui/material";

// Import mock beach data
import { mockBeaches } from "../data/mockBeaches";

// Import icons from Lucide React for the weather/surf information
import { Wind, Waves, Timer } from "lucide-react";

// Import the primary color from the theme
import { primaryColor } from "../config/theme";

// Define and export the BeachDetailsPage component
export function BeachDetailsPage() {
  // Extract the 'id' parameter from the URL
  // For example, if the URL is /beaches/1, then id will be "1"
  const { id } = useParams();

  // Find the beach with the matching id from our mock data
  // The find() method returns the first element that satisfies the condition
  const beach = mockBeaches.find((b) => b.id === id);

  // If no beach is found with the given id, display an error message
  if (!beach) {
    return (
      <Container>
        <Typography variant="h4">Beach not found</Typography>
      </Container>
    );
  }

  // Get the first forecast data item (today's forecast)
  const forecast = beach.forecastData[0];

  // Render the beach details page
  return (
    // Main container box with white background and minimum height
    <Box sx={{ bgcolor: "#fff", minHeight: "100vh" }}>
      {/* Content container with maximum width and padding */}
      <Container
        maxWidth="lg"
        sx={{ py: 4 }}
      >
        {/* Display the beach image */}
        <Box
          component="img" // Renders as an <img> element
          src={beach.imageUrl} // Image source URL
          alt={beach.name} // Accessibility text
          sx={{
            // Custom styles
            width: "100%", // Full width of container
            height: { xs: "300px", md: "500px" }, // Responsive height based on screen size
            objectFit: "cover", // Image covers the entire area
            borderRadius: 4, // Rounded corners (4 * 8px = 32px)
            mb: 4, // Margin bottom
          }}
        />

        {/* Beach name heading */}
        <Typography
          variant="h3"
          sx={{
            fontWeight: 600, // Semi-bold text
            color: "#222222", // Dark gray color
            mb: 1, // Margin bottom
          }}
        >
          {beach.name}
        </Typography>

        {/* Beach location */}
        <Typography
          variant="h6"
          sx={{
            color: "#717171", // Gray color
            mb: 3,
            fontWeight: 400,
          }}
        >
          {beach.area}
        </Typography>

        <Typography
          variant="body1"
          sx={{
            color: "#222222",
            fontSize: "1.1rem",
            mb: 4,
            maxWidth: "800px",
          }}
        >
          {beach.description}
        </Typography>

        <Typography
          variant="h5"
          sx={{
            fontWeight: 600,
            color: "#222222",
            mb: 3,
          }}
        >
          Current Conditions
        </Typography>

        <Grid
          container
          spacing={3}
        >
          <Grid
            item
            xs={12}
            md={4}
          >
            <Paper
              sx={{
                p: 3,
                textAlign: "center",
                borderRadius: 3,
                boxShadow: "0 6px 16px rgba(0,0,0,0.12)",
              }}
            >
              <Waves
                size={32}
                color={primaryColor}
              />
              <Typography
                variant="h6"
                sx={{
                  color: "#717171",
                  mt: 2,
                  mb: 1,
                }}
              >
                Wave Height
              </Typography>
              <Typography
                variant="h4"
                sx={{
                  fontWeight: 600,
                  color: "#222222",
                }}
              >
                {forecast.height}m
              </Typography>
            </Paper>
          </Grid>

          <Grid
            item
            xs={12}
            md={4}
          >
            <Paper
              sx={{
                p: 3,
                textAlign: "center",
                borderRadius: 3,
                boxShadow: "0 6px 16px rgba(0,0,0,0.12)",
              }}
            >
              <Timer
                size={32}
                color={primaryColor}
              />
              <Typography
                variant="h6"
                sx={{
                  color: "#717171",
                  mt: 2,
                  mb: 1,
                }}
              >
                Swell
              </Typography>
              <Typography
                variant="h4"
                sx={{
                  fontWeight: 600,
                  color: "#222222",
                }}
              >
                {forecast.swell}s
              </Typography>
            </Paper>
          </Grid>

          <Grid
            item
            xs={12}
            md={4}
          >
            <Paper
              sx={{
                p: 3,
                textAlign: "center",
                borderRadius: 3,
                boxShadow: "0 6px 16px rgba(0,0,0,0.12)",
              }}
            >
              <Wind
                size={32}
                color={primaryColor}
              />
              <Typography
                variant="h6"
                sx={{
                  color: "#717171",
                  mt: 2,
                  mb: 1,
                }}
              >
                Wind Speed
              </Typography>
              <Typography
                variant="h4"
                sx={{
                  fontWeight: 600,
                  color: "#222222",
                }}
              >
                {forecast.kph} kph
              </Typography>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </Box>
  );
}
