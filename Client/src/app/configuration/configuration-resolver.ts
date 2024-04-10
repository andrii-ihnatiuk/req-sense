import { Configuration } from "./configuration";

export const appConfiguration = new Configuration();

export async function resolveConfiguration(): Promise<void> {
  const configLocation = "/assets/configuration/config.json";
  const response = await fetch(configLocation);

  const config = await response.json();

  Object.keys(appConfiguration).forEach((prop) => {
    if (!config[prop]) {
      return;
    }

    (appConfiguration as any)[prop] = config[prop];
  });
}