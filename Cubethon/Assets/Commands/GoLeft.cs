namespace Chapter.Command
{
    public class GoLeft : Command
    {
        private MovementController movementController;

        public GoLeft(MovementController controller)
        {
            movementController = controller;
        }

        public override void Execute()
        {
            movementController.Turn(MovementController.Direction.Left);
        }
    }
}
