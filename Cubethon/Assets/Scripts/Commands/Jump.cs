namespace Chapter.Command
{
    public class Jump : Command
    {
        private PlayerController playerController;
        public Jump(PlayerController controller)
        {
            playerController = controller;
        }
        public override void Execute()
        {
            playerController.Jump();
        }
    }
}