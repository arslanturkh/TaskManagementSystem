using BCrypt.Net;

namespace TaskManagementApp.Helpers
{
    public static class PasswordHasher
    {
        // Hashes a password using BCrypt
        public static string HashPassword(string password)
        {
            // Work Factor determines the computational complexity (default is 10)
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        // Verifies a password against a hash
        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
