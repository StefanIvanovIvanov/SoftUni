"use strict";
var LoggingLevel;
(function (LoggingLevel) {
    LoggingLevel["Info"] = "Info";
    LoggingLevel["Error"] = "Error";
    LoggingLevel["Warning"] = "Warning";
    LoggingLevel["Debug"] = "Debug";
})(LoggingLevel || (LoggingLevel = {}));
var LoggingFormat;
(function (LoggingFormat) {
    LoggingFormat["Standard"] = "[%level][%date] %text";
    LoggingFormat["Minimal"] = "*%level* %text";
})(LoggingFormat || (LoggingFormat = {}));
class Logger {
    format;
    cachedLogs = new Map();
    log(logLevel, message) {
        const date = new Date().toISOString();
        const filledMessage = this.format.replace('%level', logLevel).replace('%date', date).replace('%text', message);
        console.log(filledMessage);
        const currentMessages = this.cachedLogs.get(logLevel);
        if (currentMessages) {
            currentMessages.push(filledMessage);
            this.cachedLogs.set(logLevel, currentMessages);
        }
        else {
            this.cachedLogs.set(logLevel, [filledMessage]);
        }
    }
    ;
    getFormat() {
        return this.format;
    }
    constructor(format) {
        this.format = format;
    }
}
let logger = new Logger(LoggingFormat.Standard);
logger.log(LoggingLevel.Info, "This is an info message.");
logger.log(LoggingLevel.Info, "Another message.");
logger.log(LoggingLevel.Error, "Something went wrong.");
logger.log(LoggingLevel.Warning, "Be careful with the type assertions.");
logger.log(LoggingLevel.Debug, "Running the debugger.");
console.log('-----------');
console.log([...logger.cachedLogs.entries()].map(x => x[1].join('\n')).join('\n'));
let logger2 = new Logger(LoggingFormat.Minimal);
logger2.log(LoggingLevel.Info, "Just a simple message.");
logger2.log(LoggingLevel.Error, "A Problem happened.");
console.log('-----------');
console.log(logger2.getFormat());
console.log([...logger2.cachedLogs.entries()].map(x => x[1].join('\n')).join('\n'));
// let logger3 = new Logger<LoggingLevel, LoggingFormat>("%text"); //TS Error
// let wronglogger = new Logger<string, LoggingLevel>();          //TS Error
// logger3.log("%s", "Running the debugger.");                     //TS Error
// logger3.log({format: "Test %s"}, "Running the debugger.");      //TS Error
//# sourceMappingURL=05.CachingLogger.js.map