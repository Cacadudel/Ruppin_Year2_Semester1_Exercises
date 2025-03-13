// This file contains mock (fake) user data for testing authentication
// In a real application, user data would be stored in a secure database
// and passwords would be encrypted/hashed
// This is just for demonstration and learning purposes

// Export an array of mock users that can be used for testing login functionality
export const mockUsers = [
  {
    id: "1", // Unique identifier for the user
    email: "john@example.com", // User's email address (used as username)
    password: "password123", // In a real app, never store plain text passwords!
    firstName: "John", // User's first name
    lastName: "Doe", // User's last name
    profilePicture: null, // No profile picture (will use first letter of email for avatar)
    favoriteBeaches: ["1", "3"], // IDs of beaches the user has favorited
    role: "user", // Regular user role
    dateJoined: "2024-01-15", // When the user created their account
  },
  {
    id: "2",
    email: "sarah@example.com",
    password: "surfingfan456",
    firstName: "Sarah",
    lastName: "Smith",
    profilePicture: "https://randomuser.me/api/portraits/women/65.jpg", // Example profile picture URL
    favoriteBeaches: ["2", "4", "5"],
    role: "user",
    dateJoined: "2024-02-10",
  },
  {
    id: "3",
    email: "alex@surfspots.com",
    password: "admin789",
    firstName: "Alex",
    lastName: "Johnson",
    profilePicture: "https://randomuser.me/api/portraits/men/42.jpg",
    favoriteBeaches: ["1", "2", "3", "4"],
    role: "admin", // Administrator role with more privileges
    dateJoined: "2023-11-05",
  },
  {
    id: "4",
    email: "mike@example.com",
    password: "mikepass",
    firstName: "Mike",
    lastName: "Wilson",
    profilePicture: null,
    favoriteBeaches: ["6"],
    role: "user",
    dateJoined: "2024-03-01",
  },
  {
    id: "5",
    email: "emma@example.com",
    password: "emma2024",
    firstName: "Emma",
    lastName: "Brown",
    profilePicture: "https://randomuser.me/api/portraits/women/22.jpg",
    favoriteBeaches: [],
    role: "user",
    dateJoined: "2024-03-20",
  },
];

// Store our users array in localStorage for persistence
// In a real app, this would be stored in a database
const initializeMockUsers = () => {
  // Only initialize if it hasn't been done already
  if (!localStorage.getItem("mockUsersInitialized")) {
    localStorage.setItem("mockUsers", JSON.stringify(mockUsers));
    localStorage.setItem("mockUsersInitialized", "true");
  }
};

// Call the initialization function
initializeMockUsers();

// Function to get the current users from localStorage
const getCurrentUsers = () => {
  const usersJson = localStorage.getItem("mockUsers");
  return usersJson ? JSON.parse(usersJson) : mockUsers;
};

// Function to save the users to localStorage
const saveUsers = (users) => {
  localStorage.setItem("mockUsers", JSON.stringify(users));
};

// This function simulates authenticating a user with email and password
// It would be replaced by a real API call in a production application
export function authenticateUser(email, password) {
  // Get current users from localStorage
  const currentUsers = getCurrentUsers();

  // Find a user with matching email and password
  const user = currentUsers.find(
    (user) =>
      user.email.toLowerCase() === email.toLowerCase() &&
      user.password === password
  );

  // If no matching user is found, return null
  if (!user) {
    return null;
  }

  // Return user data without the password for security
  // In a real app, you'd return a JWT token or similar for authentication
  const { password: _password, ...userWithoutPassword } = user;
  return userWithoutPassword;
}

// Function to get a user by ID
export function getUserById(userId) {
  // Get current users from localStorage
  const currentUsers = getCurrentUsers();

  const user = currentUsers.find((user) => user.id === userId);
  if (!user) return null;

  // Return user data without password
  const { password: _password, ...userWithoutPassword } = user;
  return userWithoutPassword;
}

// Function to register a new user
export function registerUser(userData) {
  // Get current users from localStorage
  const currentUsers = getCurrentUsers();

  // Check if email already exists
  if (
    currentUsers.some(
      (user) => user.email.toLowerCase() === userData.email.toLowerCase()
    )
  ) {
    return { success: false, error: "Email already exists" };
  }

  // Generate a new unique ID (in a real app, this would be done by the database)
  const newId = (
    Math.max(...currentUsers.map((user) => parseInt(user.id)), 0) + 1
  ).toString();

  // Create the new user with today's date
  const newUser = {
    id: newId,
    ...userData,
    profilePicture: null,
    favoriteBeaches: [],
    role: "user",
    dateJoined: new Date().toISOString().split("T")[0],
  };

  // Add new user to the array
  const updatedUsers = [...currentUsers, newUser];

  // Save to localStorage
  saveUsers(updatedUsers);

  // Return user data without password
  const { password: _password, ...userWithoutPassword } = newUser;
  return { success: true, user: userWithoutPassword };
}
