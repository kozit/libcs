namespace libcs {

    public static class Core {
        internal static App app;
        // this will be the first thing called
        public static void Init(App app) {
            Core.app = app;
            
        }

    }

}
