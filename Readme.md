# Keygen for LootScanner plugin based on the ExileAPI

## Analysis history

1. Original is `LootScanner.dll`
2. Two different obfuscators was applied (already was hacked)?
3. Was found certificate pinning method which always returns true and doesn't called to somewhere (hacked before?)
4. Current license handling is: Duration of key + machine id + AES
5. Applied anti-tamper. In case change of code it will crash silently
6. Good obfuscator was applied. Automated tools failed to deobfuscate.

## Reverse history

### Manual analysis with debugging ✅

1. Retrieved encryption key for activation key decryption 
2. Retrieved pattern of content of activation key: `---Days:(\d+) --- Y:(\d+) --- M:(\d+) --- D:(\d+) --- Machine:(.+)`

Result: success. Based on analysis keygen was written.

### Aggressive codebase change ❌

1. Change method `GetCryptoToken` to always return same string
2. Change field `CryptoTokenValid` to always return same string

Result: failed. Unable to found anti tamper. Application crashes silently. I think stack overflow exception being raised.