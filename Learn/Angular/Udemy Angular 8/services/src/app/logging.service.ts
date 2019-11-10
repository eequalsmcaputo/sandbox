export class LoggingService {
  logStatusChange(name: string, status: string) {
    console.log('Account ' + name + ' status changed. New status: ' + status);
  }
}
