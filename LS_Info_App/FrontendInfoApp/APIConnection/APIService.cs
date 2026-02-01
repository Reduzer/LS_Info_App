namespace FrontendInfoApp.APIConnection {
    internal class APIService {
        private static APIService instance;

        private Guid m_oSessionToken;
        private GetFromAPI m_oGetService;

        private APIService() {
            m_oGetService = new GetFromAPI();
        }

        public static APIService Instance {
            get {
                if (instance == null) {
                    instance = new APIService();
                }
                return instance;
            }
        }

        public GetFromAPI Get() {
            return m_oGetService;
        }
    }
}