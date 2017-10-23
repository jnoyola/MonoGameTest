namespace MonoGameTest
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
            using (var game = new MonoGameTest())
            {
                game.Run();
            }
		}
	}
}