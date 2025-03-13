// This file creates an authentication system using React Context
// Context allows data to be passed through component tree without passing props manually

// Import necessary hooks and functions from React
import { createContext, useContext, useState, useEffect } from "react";
// createContext: Creates a Context object for sharing data
// useContext: Hook to use a Context
// useState: Hook to add state to functional components
// useEffect: Hook to perform side effects (like data fetching)

// Import helper functions and mock data for authentication
import { authenticateUser, getUserById } from "../data/mockUsers";

// Create a new Context for authentication
// This will store and provide authentication data throughout the app
const AuthContext = createContext(null);

// AuthProvider component that will wrap our application
// It provides authentication state and functions to all child components
export function AuthProvider({ children }) {
  // Create a state to store the current user
  // Initially user is null (not logged in)
  const [user, setUser] = useState(null);

  // This effect runs once when the component mounts
  useEffect(() => {
    // Check if user data exists in browser's localStorage
    // localStorage persists data even after browser is closed
    const storedUserId = localStorage.getItem("userId");
    if (storedUserId) {
      // If user ID exists, get the user data from our mock database
      // In a real app, you would fetch this from a server API
      const userData = getUserById(storedUserId);
      if (userData) {
        // If user data exists, set it as the current user (auto-login)
        setUser(userData);
      }
    }
  }, []); // Empty dependency array means this runs only once when component mounts

  // Function to log a user in
  const login = (email, password) => {
    // Check if email and password match a user in our mock database
    const userData = authenticateUser(email, password);

    if (userData) {
      // If authentication successful, update the user state with user data
      setUser(userData);
      // Save user ID to localStorage for persistence across page refreshes
      localStorage.setItem("userId", userData.id);
      return { success: true };
    } else {
      // If authentication failed, return error
      return { success: false, error: "Invalid email or password" };
    }
  };

  // Function to log a user out
  const logout = () => {
    // Set user state to null (no user logged in)
    setUser(null);
    // Remove user ID from localStorage
    localStorage.removeItem("userId");
  };

  // Provide the authentication context to all child components
  // Any component wrapped by AuthProvider can access user, login, and logout
  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

// Custom hook that makes it easy to use the auth context in any component
// Instead of using useContext(AuthContext) directly, components can just use useAuth()
export const useAuth = () => useContext(AuthContext);
