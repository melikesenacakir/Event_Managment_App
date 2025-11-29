export interface ApiConfig {
  apiBaseUrl: string;
  timeout: number;
  headers: {
    [key: string]: string;
  };
}

export interface PublicEndpoints {
  login: string;
  register: string;
}

export interface EventEndpoints {
  getEvents: string;
  getEvent: string;
  joinEvent: string;
}

export interface UserEndpoints {
  getUser: string;
  getUsers: string;
  createUser: string;
  updateUser: string;
  deleteUser: string;
}

export interface PrivateEndpoints {
  home: string;
  events: EventEndpoints;
  users: UserEndpoints;
}

export interface ApiEndpoints {
  public: PublicEndpoints;
  private: PrivateEndpoints;
}

export const config: ApiConfig = {
  apiBaseUrl: "http://localhost:5000/api",
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
};

export const endpoints: ApiEndpoints = {
  public: {
    login: "/public/auth/login",
    register: "/public/auth/register",
  },
  private: {
    home: "/private/homepage",
    events: {
      getEvents: "/private/events",
      getEvent: "/private/events",
      joinEvent: "/private/events/participate",
    },
    users: {
      getUser: "/private/users",
      getUsers: "/private/users",
      createUser: "/private/users",
      updateUser: "/private/users",
      deleteUser: "/private/users",
    },
  },
};

export const buildApiUrl = (endpoint: string): string => {
  return `${config.apiBaseUrl}${endpoint}`;
};
