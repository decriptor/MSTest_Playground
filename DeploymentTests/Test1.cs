namespace DeploymentTests
{
    [TestClass]
    [DeploymentItem("TestFile.txt")]
    public sealed class Test1
    {
        public TestContext TestContext { get; set; }

        //[AssemblyInitialize]
        //public static void AssemblyInit(TestContext context)
        //{
        //    // This method is called once for the test assembly, before any tests are run.
        //}

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [DeploymentItem(@"Resources\TestFile2.txt")]
        public void TestMethod2()
        {
            // The path where the file should be deployed
            string deployedFilePath = Path.Combine(TestContext.DeploymentDirectory, "testfile.txt");
            string deployedFilePath2 = Path.Combine(TestContext.DeploymentDirectory, "testfile2.txt");

            // Here we go, checking for the existence of the file...
            bool fileExists = File.Exists(deployedFilePath);
            bool fileExists2 = File.Exists(deployedFilePath2);

            // If the file doesn't exist, we're in for a cosmic mix-up
            Assert.IsTrue(fileExists, $"Houston, we have a problem. Expected file '{deployedFilePath}' not found!");
            Assert.IsTrue(fileExists2, $"Houston2, we have a problem. Expected file '{deployedFilePath2}' not found!");

            // Additional check, just for the fun of it.
            // Let's see if we can read from it, or if it's as empty as the Hitchhiker's Guide's entry on Earth.
            if (fileExists)
            {
                Assert.IsTrue(new FileInfo(deployedFilePath).Length > 0, "File exists, but it's as empty as space itself!");
            }
        }
    }
}
