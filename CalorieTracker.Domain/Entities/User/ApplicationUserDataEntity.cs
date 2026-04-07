
using CalorieTracker.Domain.Entities.Activity_Level;
using CalorieTracker.Domain.Entities.FitnessGoal;
using Domain.Entities.User;

namespace CalorieTracker.Domain.Entities.User
{
    public class ApplicationUserDataEntity
    {
        public Guid Id { get; set; }
        public Guid ActivityLevelId { get; set; }
        public Guid FitnessGoalId { get; set; }
        public short Height { get; set; }
        public short Weight { get; set; }
        public byte Age { get; set; }
        public ApplicationUserEntity? User { get; set; } 
        public ActivityLevelEntity? ActivityLevel { get; set; }
        public FitnessGoalEntity? FitnessGoal { get; set; }
    }
}
