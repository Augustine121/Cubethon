namespace Chapter.Command
{
    public class MoveLeft : Command
    {
        private PlayerController playerController;
        public MoveLeft(PlayerController controller)
        {
            playerController = controller;
        }
        public override void Execute()
        {
            playerController.MoveLeft();
        }
    }
}
