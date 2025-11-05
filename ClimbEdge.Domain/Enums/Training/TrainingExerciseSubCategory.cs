using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Enums.Training
{
    public enum TrainingExerciseSubCategory
    {
        /// <summary>
        /// Exercises that use only the individual's body weight for resistance.
        /// </summary>
        Bodyweight,
        /// <summary>
        /// Exercises that involve additional weights or resistance equipment.
        /// </summary>
        Weighted,
        /// <summary>
        /// Exercises that focus on explosive movements to improve power and speed.
        /// </summary>
        Plyometric,
        /// <summary>
        /// Exercises that involve static holds or slow movements to build endurance.
        /// </summary>
        Isometric
    }
}
