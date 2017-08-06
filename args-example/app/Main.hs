module Main where

import Lib
import Data.Monoid ((<>))
import Options.Applicative
import Network.URI (URI, parseURI)

data Configuration =
  Configuration
    { apiUri  :: URI
    , dryRun  :: Bool
    , verbose :: Bool }
  deriving (Show)

apiUriOption :: Parser URI
apiUriOption =
  option (maybeReader parseURI)
    ( long "api-uri"
    <> metavar "URI"
    <> help "The URI to the API" )

dryRunFlag :: Parser Bool
dryRunFlag =
  flag False True
  ( short 'd'
  <> long "dry-run"
  <> help "Enables dry-run mode" )

verboseFlag :: Parser Bool
verboseFlag =
  flag False True
  ( short 'v'
  <> long "verbose"
  <> help "Enables verbose logging" )

configurationParser :: Parser Configuration
configurationParser =
  Configuration
    <$> apiUriOption -- map
    <*> dryRunFlag   -- apply
    <*> verboseFlag  -- apply

main :: IO ()
main = do
  configuration <- execParser $ info (helper <*> configurationParser) fullDesc
  print configuration
