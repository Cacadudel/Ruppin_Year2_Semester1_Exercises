// This file contains the HomePage component which displays the main landing page of our app

// Import necessary Material UI components for layout and styling
import { Container, Grid, Typography, Box } from "@mui/material";
// Container: Centers content horizontally with maximum width
// Grid: Creates responsive layouts using a 12-column grid system
// Typography: For consistent text styling
// Box: A wrapper component for most CSS utility needs

// Import the BeachCard component that will display each beach
import { BeachCard } from "../components/BeachCard";

// Import mock data containing beach information
import { mockBeaches } from "../data/mockBeaches";

// Define and export the HomePage component
export function HomePage() {
  return (
    // Box component creates a container with white background and minimum height of 100% viewport
    <Box sx={{ bgcolor: "#fff", minHeight: "100vh" }}>
      {/* Container centers content and adds maximum width (lg = large) */}
      {/* py: 6 adds padding top and bottom (6 * 8px = 48px in Material UI) */}
      <Container
        maxWidth="lg"
        sx={{ py: 6 }}
      >
        {/* Typography for main heading */}
        <Typography
          variant="h3" // Size of the text (heading level 3)
          component="h1" // Actual HTML element to render (h1 for SEO)
          gutterBottom // Adds margin-bottom
          sx={{
            // Custom styles
            fontWeight: 600, // Makes text semi-bold
            color: "#222222", // Dark gray color
            fontSize: { xs: "2rem", md: "2.5rem" }, // Responsive font size: smaller on mobile (xs), larger on medium (md) screens
          }}
        >
          Discover Perfect Waves
        </Typography>

        {/* Typography for subheading */}
        <Typography
          variant="h6" // Size of the text (heading level 6)
          sx={{
            // Custom styles
            color: "#717171", // Gray color
            mb: 4, // Margin bottom (4 * 8px = 32px in Material UI)
            fontWeight: 400, // Regular font weight
          }}
        >
          Explore the world's best surfing destinations
        </Typography>

        {/* Grid container to hold beach cards in a responsive layout */}
        {/* spacing={3} adds gap between grid items (3 * 8px = 24px) */}
        <Grid
          container
          spacing={3}
        >
          {/* Map through the beach data array and create a card for each beach */}
          {mockBeaches.map((beach) => (
            // Grid item defines how many columns each card takes at different screen sizes:
            // MUI use 12 columns for the grid system
            // xs={12}: On extra small screens (mobile), take full width (12 columns)
            // sm={6}: On small screens (tablets), take half width (6 columns)
            // md={4}: On medium screens (desktop), take one-third width (4 columns)
            <Grid
              item
              key={beach.id}
              xs={12}
              sm={6}
              md={4}
            >
              {/* BeachCard component displays the beach information */}
              {/* Pass the beach data as a prop to the BeachCard component */}
              <BeachCard beach={beach} />
            </Grid>
          ))}
        </Grid>
      </Container>
    </Box>
  );
}
