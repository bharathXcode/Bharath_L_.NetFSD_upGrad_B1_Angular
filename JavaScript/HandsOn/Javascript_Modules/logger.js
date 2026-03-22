// logger.js
function logInfo(message) {
    console.log(`INFO: ${message}`);
}

function logError(message) {
    console.error(`ERROR: ${message}`);
}

const logLevel = {
    INFO: 'info',
    ERROR: 'error'
};

// Exporting multiple values using module.exports
module.exports = {
    logInfo,
    logError,
    logLevel
};
