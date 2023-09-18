namespace Chapter.Command
{
    public class GoRight : Command
    {
        private MovementController movementController;

        public GoRight(MovementController controller)
        {
            movementController = controller;
        }

        public override void Execute()
        {
            movementController.Turn(MovementController.Direction.Right);
        }
    }
}