import React from "react";
import { Container, Typography } from "@mui/material";
import { Box } from "@mui/material";
import { Link } from "react-router-dom";

function Footer() {
  return (
    <Box
      component="footer"
      sx={{
        pt: 4,
        pb: 4,
        bgcolor: "#f0f0f0",
      }}
    >
      <Container maxWidth="md">
        <Typography
          variant="body2"
          color="textSecondary"
          align="center"
        >
          &copy; {new Date().getFullYear()} Surfline. All rights reserved.
        </Typography>

        <ul style={{ display: "flex", justifyContent: "center", gap: 12 }}>
          <li>
            <Link to="#">Home</Link>
          </li>
          <li>
            <Link to="#">About</Link>
          </li>
          <li>
            <Link to="#">Contact</Link>
          </li>
          <li>
            <Link to="#">Terms</Link>
          </li>
        </ul>
      </Container>
    </Box>
  );
}

export default Footer;
