# Keygen for LootScanner plugin based on the ExileAPI

## Analysis history

1. The original is `LootScanner.dll`
2. Two different obfuscators were applied (already hacked?).
3. A certificate pinning method was found that always returns true and isn't called anywhere (previously hacked?).
4. Current license handling includes: Duration of key + machine ID + AES.
5. Anti-tamper applied. If code changes, it will crash silently.
6. A robust obfuscator was used. Automated tools failed to deobfuscate.

## Reverse Engineering History

### Manual analysis with debugging ✅

1. Retrieved the encryption key for activation key decryption.
2. Retrieved the pattern of the content of the activation key: `---Days:(\d+) --- Y:(\d+) --- M:(\d+) --- D:(\d+) --- Machine:(.+)`

Result: Successful. Based on the analysis, a keygen was written. The original was not altered.

### Aggressive codebase change ❌

1. Changed the method `GetCryptoToken` to always return the same string
2. Changed the field `CryptoTokenValid` to always return the same string

Result: Failed. Unable to locate anti-tamper. The application crashes silently; I suspect a stack overflow exception is being raised.
