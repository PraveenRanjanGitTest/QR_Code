const {
    API_URL,
    ENVIRONMENT
} = (window as any).__env__

export const env: Environment = {
    apiUrl: API_URL,
    env: ENVIRONMENT
}

type Environment = {
    apiUrl: string
    env: string
}