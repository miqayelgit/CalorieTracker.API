
using CalorieTracker.Domain.Entities.ActivityGoals;
using CalorieTracker.Domain.Entities.ActivityGoals;
using Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.User
{
    public class ApplicationUserData
    {
        public Guid Id { get; set; }
        public Guid ActivityLevelId { get; set; }
        public Guid FitnessGoalId { get; set; }
        public short Height { get; set; }
        public short Weight { get; set; }
        public byte Age { get; set; }
        public ApplicationUser? User { get; set; } 
        public ActivityLevel? ActivityLevel { get; set; }
        public FitnessGoal? FitnessGoal { get; set; }
    }
}
