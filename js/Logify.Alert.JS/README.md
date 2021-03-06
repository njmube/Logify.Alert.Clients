# Logify Alert for JavaScript

A JavaScript client for reporting exceptions to [Logify Alert](https://logify.devexpress.com/).

## Links to script

The latest version of the JavaScript client is available by the following links:
```
https://logifyjs.devexpress.com/logifyAlert.js - full version
https://logifyjs.devexpress.com/logifyAlert.min.js - minified version
```

Additionally, there are clients for specific Logify Alert versions. For example:
```
https://logifyjs.devexpress.com/0.0.4/logifyAlert.js - full version
https://logifyjs.devexpress.com/0.0.4/logifyAlert.min.js - minified version
```

## Quick Start

```javascript
<script type="text/javascript" src="https://logifyjs.devexpress.com/logifyAlert.min.js"/>

<script type="text/javascript"/>
	var logify = new logifyAlert("SPECIFY_YOUR_API_KEY_HERE");
	logify.applicationName = "Test application";
	logify.startHandling();
</script>
```

## API

### Fields

#### applicationName

Specifies the application name. This name is shown in generated reports.

```javascript
client.applicationName = 'My Application';
```

#### applicationVersion

Specifies the application version. This version is shown in generated reports. 

```javascript
client.applicationVersion = '1.0.1';
```

#### userId

Specifies a unique user identifier that corresponds to a sent report.

```javascript
client.userId = 'unique user id';
```

#### customData

A dictionary that contains custom data sent with a generated report. 

```javascript
client.customData = {FIRST_KEY:  "FIRST DATA", SECOND_KEY: "SECOND DATA"};
```

#### collectInputs

Boolean. The default value is **false**. Assign **true** to the *collectInputs* property to collect all inputs passed to a web page (except for the passwords). The collected information stores an input's type, identifier, tag name and value.

```javascript
client.collectInputs = true;
```

#### collectLocalStorage

Specifies whether or not Logify Alert client will collect local storage data. Default value is **false**.

```javascript
client.collectLocalStorage = true;
```

#### collectSessionStorage

Specifies if Logify Alert client will correct session storage data. The default value is **true**.

```javascript
client.collectSessionStorage = false;
```

#### collectCookies

Specifies whether or not the Logify Alert client will collect cookies. The default value is **true**.

```javascript
client.collectCookies = false;
```

### Methods for automatic reporting

Logify Alert allows you to automatically listen to uncaught exceptions and rejections, and deliver crash reports. For this purpose, use the methods below.

#### startHandling()

Commands Logify Alert to start listening to uncaught exceptions and rejections and send reports for all processed exceptions. 

```javascript
client.startHandling();
```

#### stopHandling()

Commands Logify Alert to stop listening to uncaught exceptions and rejections. 

```javascript
client.stopHandling();
```

### Methods for manual reporting

Alternatively, Logify Alert allows you to catch required exceptions manually, generate reports based on caught exceptions and send these reports only. For this purpose, use the methods below.

#### sendException(errorMsg, url, lineNumber, column, errorObj)

Sends information about the caught exception to the Logify Alert server.

```javascript
client.sendException(errorMsg, url, lineNumber, column, errorObj);
```

#### sendRejection(reason, promise)

Sends information about the caught rejection to the Logify Alert server.

```javascript
client.sendRejection(reason, promise);
```

### Callbacks

#### beforeReportException(customData)

Specifies a delegate to be called before sending exceptions and rejections to the Logify Alert server.

The *customData* parameter holds custom data sent along with an exception or a rejection. The default value is *undefined*. If you change a parameter value within a callback, a new value will be stored and passed to a callback the next time you call it in your application.

```javascript
client.beforeReportException = function (customData) {
        if (customData == undefined) {
            customData = {};
        }
        customData["test key"] = "test value";
        return customData;
}
```
