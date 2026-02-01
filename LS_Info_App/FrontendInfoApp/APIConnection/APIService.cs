namespace FrontendInfoApp.APIConnection {
    internal class APIService {
        private static APIService instance;

        private Guid m_oSessionToken;
        private GetFromAPI m_oGetService;
        //private PostToAPI m_oPostService;
        //private PutToAPI m_oPutService;
        //private DeleteToAPI m_oDeleteService;

        private APIService() {
            m_oGetService = new GetFromAPI();
            //m_oPostService = new PostToAPI();
            //m_oPutService = new PutToAPI();
            //m_oDeleteService = new DeleteToAPI();
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

        /*public PostToAPI Post() {
            return m_oPostService;
        }

        public PutToAPI Put() {
            return m_oPutService;
        }

        public DeleteToAPI Delete() {
            return m_oDeleteService;
        }*/
    }
}