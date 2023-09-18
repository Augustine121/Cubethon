namespace Chapter.Command
{
    public class Jump : Command
    {
        private MovementController movementController;

        public Jump(MovementController controller)
        {
            movementController = controller;
        }

        public override void Execute()
        {
            movementController.Jump();
        }
    }
}