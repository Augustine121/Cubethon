namespace Chapter.Command
{
    public class MoveRight : Command
    {
        private PlayerController playerController;
        public MoveRight(PlayerController controller)
        {
            playerController = controller;
        }
        public override void Execute()
        {
            playerController.MoveRight();
        }
    }
}