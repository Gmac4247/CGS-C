using System;

namespace AlternativeGeometry
{
    /// <summary>
    /// Provides alternative geometric formulas for area, circumference, and volume calculations.
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        /// Calculates the area of a circle using the formula: 3.2 × r².
        /// </summary>
        /// <param name="r">The radius of the circle.</param>
        /// <returns>The area of the circle.</returns>
        public static double AreaOfCircle(double r)
        {
            return 3.2 * r * r;
        }

        /// <summary>
        /// Calculates the circumference of a circle using the formula: 6.4 × r.
        /// </summary>
        /// <param name="r">The radius of the circle.</param>
        /// <returns>The circumference of the circle.</returns>
        public static double CircumferenceOfCircle(double r)
        {
            return 6.4 * r;
        }

        /// <summary>
        /// Calculates the volume of a sphere using the formula: (√3.2 × r)³.
        /// </summary>
        /// <param name="r">The radius of the sphere.</param>
        /// <returns>The volume of the sphere.</returns>
        public static double VolumeOfSphere(double r)
        {
            return Math.Pow(Math.Sqrt(3.2) * r, 3);
        }

        /// <summary>
        /// Calculates the volume of a cone using the formula: 3.2 × r² × height / √8.
        /// </summary>
        /// <param name="r">The radius of the cone's base.</param>
        /// <param name="height">The height of the cone.</param>
        /// <returns>The volume of the cone.</returns>
        public static double VolumeOfCone(double r, double height)
        {
            return (3.2 * r * r * height) / Math.Sqrt(8);
        }
    }
}
